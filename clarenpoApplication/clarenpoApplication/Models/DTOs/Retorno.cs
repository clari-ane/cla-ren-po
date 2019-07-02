using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clarenpoApplication.Models.DTOs
{
    public class RetornoJogada
    {
        public int NoSuchStrategyError { get; set; }
        public int WrongNumberOfPlayersError { get; set; }
        public string NomeVencedor { get; set; }
        
        public string SinalVencedor { get; set; }

    }
}