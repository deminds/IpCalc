using System;

namespace GH.DD.IpCalc
{
    public class Parser
    {
        public int[] ParseDec(string octets, char separator = '.')
        {
            var octetsSplit = octets.Split(separator);
            if (octetsSplit.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error parse raw: {octets}. Octets count != {Ipv4Constants.OctetsCount}");
            
            var result = new int[Ipv4Constants.OctetsCount];

            for (var i = 0; i < Ipv4Constants.OctetsCount; i++)
            {
                if (!TryParseDecOctet(octetsSplit[i], out int octet))
                    throw new FormatException($"Error parse octet: {octetsSplit[i]} to dec");
                
                result[i] = octet;
            }

            return result;
        }

        public int[] ParseDec(string[] octets)
        {
            if (octets.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error parse raw: {octets}. Octets count != {Ipv4Constants.OctetsCount}");
            
            var result = new int[Ipv4Constants.OctetsCount];

            for (int i = 0; i < Ipv4Constants.OctetsCount; i++)
            {
                if (!TryParseDecOctet(octets[i], out var octet))
                    throw new FormatException($"Error parse octet: {octets[i]} to dec. Raw octets: {octets}");
                
                result[i] = octet;
            }
                
            return result;
        }
        
        public int[] ParseDec(int[] octets)
        {
            if (octets.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error parse raw: {octets}. Octets count != {Ipv4Constants.OctetsCount}");
                
            return octets;
        }
        
        public int[] ParseBin(string octets, char separator = '.')
        {
            var octetsSplit = octets.Split(separator);
            if (octetsSplit.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error parse raw: {octets}. Octets count != {Ipv4Constants.OctetsCount}");
            
            var result = new int[Ipv4Constants.OctetsCount];

            for (var i = 0; i < Ipv4Constants.OctetsCount; i++)
            {
                if (!TryParseBinOctet(octetsSplit[i], out int octet))
                    throw new FormatException($"Error parse octet: {octetsSplit[i]} to bin");
                
                result[i] = octet;
            }
            
            return result;
        }

        public int[] ParseBin(string[] octets)
        {
            if (octets.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error parse raw: {octets}. Octets count != {Ipv4Constants.OctetsCount}");
            
            var result = new int[Ipv4Constants.OctetsCount];

            for (int i = 0; i < Ipv4Constants.OctetsCount; i++)
            {
                if (!TryParseBinOctet(octets[i], out var octet))
                    throw new FormatException($"Error parse octet: {octets[i]} to bin. Raw octets: {octets}");
                
                result[i] = octet;
            }
                
            return result;
        }
        
        private bool TryParseDecOctet(string octet, out int value)
        {
            return int.TryParse(octet, out value);
        }

        private bool TryParseBinOctet(string octet, out int value)
        {
            value = 0;

            try
            {
                value = Convert.ToInt32(octet, 2);
            }
            catch (InvalidCastException)
            {
                return false;
            }
            
            return true;
        }
    }
}