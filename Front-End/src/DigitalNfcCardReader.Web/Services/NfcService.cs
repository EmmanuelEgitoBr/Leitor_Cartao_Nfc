using System;
using PCSC.Exceptions;
using PCSC;
using PCSC.Iso7816;

namespace DigitalNfcCardReader.Web.Services
{
    public class NfcService
    {
        private readonly IIsoReader _isoReader;

        public NfcService(IIsoReader isoReader)
        {
            _isoReader = isoReader ?? throw new ArgumentNullException(nameof(isoReader));
        }

        public void StartNFCReader()
        {
            try
            {
                var contextFactory = ContextFactory.Instance;
                using (var context = contextFactory.Establish(SCardScope.System))
                {
                    // Encontra leitores NFC conectados
                    var readers = context.GetReaders();
                    if (readers.Length == 0)
                    {
                        //MessageBox.Show("Nenhum leitor NFC encontrado.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Conectar ao primeiro leitor disponível
                    using (var reader = context.ConnectReader(readers[0], SCardShareMode.Shared, SCardProtocol.Any))
                    {
                        // Comando para ler o UID do cartão (comando genérico ISO/IEC 7816)
                        byte[] getUidCmd = { 0xFF, 0xCA, 0x00, 0x00, 0x00 };
                        var receiveBuffer = new byte[256];
                        var commandApdu = new CommandApdu(IsoCase.Case2Short, reader.Protocol)
                        {
                            CLA = getUidCmd[0],
                            INS = getUidCmd[1],
                            P1 = getUidCmd[2],
                            P2 = getUidCmd[3],
                            Le = getUidCmd[4]
                        };

                        var responseApdu = _isoReader.Transmit(commandApdu);

                        if (responseApdu.HasData)
                        {
                            string uid = BitConverter.ToString(responseApdu.GetData()).Replace("-", ":");
                            //CardInfoTextBox.Text = $"Cartão detectado!\nUID: {uid}";
                        }
                        else
                        {
                            //CardInfoTextBox.Text = "Nenhum dado recebido do cartão.";
                        }
                    }
                }
            }
            catch (PCSCException ex)
            {
                //MessageBox.Show($"Erro ao acessar o leitor NFC: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
