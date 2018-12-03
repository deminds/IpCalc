using System;

namespace GH.DD.IpCalc
{
    public class Ip
    {
        private string[] _octetsBin;

        public int[] Octets { protected set; get; }

        public string[] OctetsBin
        {
            get => _octetsBin ?? (_octetsBin = ToBin());
            private set => _octetsBin = value;
        }

        public Ip(int[] octets)
        {
            Octets = octets;

            if (!IsValid())
                throw new FormatException($"Error parsed ip is not valid. Raw octets: {octets}");
        }

        private string[] ToBin()
        {
            var result = new string[Ipv4Constants.OctetsCount];
            for (var i = 0; i < Ipv4Constants.OctetsCount; i++)
                result[i] = Convert.ToString(Octets[i], 2).PadLeft(Ipv4Constants.OctetBinLength, '0');

            return result;
        }

        private bool IsValid()
        {
            if (Octets.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error {Octets}. Octets count != {Ipv4Constants.OctetsCount}");

            foreach (var octet in Octets)
            {
                if (IsValidOctet(octet))
                    continue;

                return false;
            }

            return true;
        }

        private bool IsValidOctet(int octet)
        {
            if (octet < Ipv4Constants.OctetMinVal)
                return false;

            if (octet > Ipv4Constants.OctetMaxVal)
                return false;

            return true;
        }
    }
}