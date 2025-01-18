using PCSC.Exceptions;
using PCSC;

namespace DigitalNfcCardReader.Web.Services
{
    public class NFCReaderService
    {
        public string ReadCard()
        {
            var contextFactory = ContextFactory.Instance;

            try
            {
                using (var context = contextFactory.Establish(SCardScope.System))
                {
                    // Obtem leitores conectados
                    var readers = context.GetReaders();
                    if (readers.Length == 0)
                    {
                        return "Nenhum leitor NFC encontrado.";
                    }

                    // Conecta ao primeiro leitor
                    using (var reader = context.ConnectReader(readers[0], SCardShareMode.Shared, SCardProtocol.Any))
                    {
                        // Comando para obter UID do cartão (comando ISO/IEC 7816 genérico)
                        byte[] getUidCmd = { 0xFF, 0xCA, 0x00, 0x00, 0x00 };
                        var receiveBuffer = new byte[256];

                        var sendPci = SCardPCI.GetPci(reader.Protocol);
                        var receivePci = new SCardPCI();
                        var bytesReceived = reader.Transmit(sendPci, getUidCmd, receiveBuffer);


                        // Formata o UID do cartão
                        return BitConverter.ToString(receiveBuffer, 0, bytesReceived).Replace("-", ":");
                    }
                }
            }
            catch (PCSCException ex)
            {
                return $"Erro ao acessar o leitor NFC: {ex.Message}";
            }
        }
    }
}
