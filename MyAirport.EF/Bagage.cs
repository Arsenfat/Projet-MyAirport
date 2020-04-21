using System;
namespace VJ.MyAirport.EF
{
    public class Bagage
    {
        /// <summary>
        /// Object bagage from me
        /// </summary>

        public int BagageID { get; set; }

        public Vol Vol { get; set; }

        public int? VolId { get; set; }

        public string CodeIata { get; set; }

        public DateTime DateCreation { get; set; }

        public char? Classe { get; set; }

        public bool? Prioritaire { get; set; }

        public char? Sta { get; set; }

        public string? Ssur { get; set; }

        public string? Destination { get; set; }

        public string? Escale { get; set; }

        public Bagage()
        {
        }

        public Bagage(string codeIata, DateTime dateCreation)
        {
            CodeIata = codeIata;
            DateCreation = dateCreation;
        }
    }
}
