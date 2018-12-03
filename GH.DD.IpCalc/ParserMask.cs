using System;
using System.Text;

namespace GH.DD.IpCalc
{
    public class ParserMask
    {
        private readonly Parser _parser;

        public ParserMask(Parser parser)
        {
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public Mask ParseDec(string octets, char separator = Ipv4Constants.OctetSeparator)
        {
            var octetsInt = _parser.ParseDec(octets, separator);
            
            return new Mask(octetsInt);
        }

        public Mask ParseDec(string[] octets)
        {
            var octetsInt = _parser.ParseDec(octets);
            
            return new Mask(octetsInt);
        }
        
        public Mask ParseDec(int[] octets)
        {
            var octetsInt = _parser.ParseDec(octets);
            
            return new Mask(octetsInt);
        }

        public Mask ParseDec(int maskLenth)
        {
            if (maskLenth < Ipv4Constants.MaskMinLength || maskLenth > Ipv4Constants.MaskMaxLength)
                throw new FormatException($"Error mask length is not valid. Raw maskLenth: {maskLenth}");

            var rawMaskBin = new StringBuilder(Ipv4Constants.MaskMaxLength + Ipv4Constants.OctetsCount - 1)
                .Insert(0, "1", maskLenth)
                .Insert(maskLenth - 1, "0", Ipv4Constants.MaskMaxLength - maskLenth);

            var octetsInt = _parser.ParseBin(rawMaskBin.ToString());
            
            return new Mask(octetsInt);
        }
        
        public Mask ParseBin(string octets, char separator = '.')
        {
            var octetsInt = _parser.ParseBin(octets, separator);
            
            return new Mask(octetsInt);
        }
        
        public Mask ParseBin(string[] octets)
        {
            var octetsInt = _parser.ParseBin(octets);
            
            return new Mask(octetsInt);
        }
    }
}