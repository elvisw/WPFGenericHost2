using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGenericHost2.Services
{
    public class TextService : ITextService
    {
        private readonly string _text;
        private readonly ILogger _logger;
        public TextService(IOptions<MySettings> options, ILogger<TextService> logger)
        {
            _logger = logger;
            _text = options.Value.Text;
            _logger.LogInformation($"Text read from settings: '{options.Value.Text}'");
        }

        public string GetText() => _text;
    }
}
