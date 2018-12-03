using System;

namespace GH.DD.IpCalc
{
    public class ParserIp
    {
        private readonly Parser _parser;

        public ParserIp(Parser parser)
        {
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public Ip ParseDec(string octets, char separator = Ipv4Constants.OctetSeparator)
        {
            var octetsInt = _parser.ParseDec(octets, separator);
            
            return new Ip(octetsInt);
        }

        public Ip ParseDec(string[] octets)
        {
            var octetsInt = _parser.ParseDec(octets);
            
            return new Ip(octetsInt);
        }
        
        public Ip ParseDec(int[] octets)
        {
            var octetsInt = _parser.ParseDec(octets);
            
            return new Ip(octetsInt);
        }
        
        public Ip ParseBin(string octets, char separator = '.')
        {
            var octetsInt = _parser.ParseBin(octets, separator);
            
            return new Ip(octetsInt);
        }
        
        public Ip ParseBin(string[] octets)
        {
            var octetsInt = _parser.ParseBin(octets);
            
            return new Ip(octetsInt);
        }

    }
}