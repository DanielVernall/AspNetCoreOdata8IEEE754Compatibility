using Microsoft.OData.Json;
using System.Text;

namespace TestIEEE754Compatibility.Models
{
    public class CustomStreamBasedJsonWriterFactory : IStreamBasedJsonWriterFactory
    {
        public IJsonWriterAsync CreateAsynchronousJsonWriter(Stream stream, bool isIeee754Compatible, Encoding encoding)
        {
            return DefaultStreamBasedJsonWriterFactory.Default.CreateAsynchronousJsonWriter(stream, isIeee754Compatible, encoding);
        }

        public IJsonWriter CreateJsonWriter(Stream stream, bool isIeee754Compatible, Encoding encoding)
        {
            return DefaultStreamBasedJsonWriterFactory.Default.CreateJsonWriter(stream, isIeee754Compatible, encoding);
        }
    }
}
