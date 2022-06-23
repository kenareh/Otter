using System.Collections.Generic;

namespace Otter.ExternalService.Sms
{
    public class SmsProviderDto
    {
        public string Text { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}