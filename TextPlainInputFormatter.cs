using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AspNetCoreVueStarter
{
    public class TextPlainInputFormatter : TextInputFormatter
    {
        public TextPlainInputFormatter()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(UTF8EncodingWithoutBOM);
            SupportedEncodings.Add(UTF16EncodingLittleEndian);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context,
            Encoding encoding)
        {
            string data = null;

            try
            {
                using (var streamReader = context.ReaderFactory(
                    context.HttpContext.Request.Body,
                    encoding))
                {
                    data = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception exception)
            {
                var e = exception;
            }

            return InputFormatterResult.Success(data);
        }
    }
}
