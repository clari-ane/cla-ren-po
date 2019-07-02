using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using clarenpoApplication.Models.DTOs;

namespace clarenpoApplication.Models.BLLs
{
    public class Jogo
    {
        public Jogo()
        {

        }

        internal RetornoJogada VerificaGanhador(Jogada[] arrJogadasRealizadas, string N1, string N2)
        {
            RetornoJogada objRetorno = new RetornoJogada();
            string strNomeDoVencedor = "", strSinalVencedor = "";
            int WrongNumberOfPlayersError = 0;
            int NoSuchStrategyError = 0;

            int.TryParse(N1, out WrongNumberOfPlayersError);
            int.TryParse(N2, out NoSuchStrategyError);

            //Fazer os IF para ver quem ganhou 

            Models.DTOs.Jogada objJogador1 = new Jogada();
            Models.DTOs.Jogada objJogador2 = new Jogada();

            objJogador1 = arrJogadasRealizadas[0];
            objJogador2 = arrJogadasRealizadas[1];

            //--------------------------------------------

            int intExistJogadaJogador1 = 0;
            int intExistJogadaJogador2 = 0;

            intExistJogadaJogador1 = objJogador1.Sinal.Count(s => s == 'S' || s == 's' || s == 'R' || s == 'r' || s == 'P' || s == 'p');
            intExistJogadaJogador2 = objJogador2.Sinal.Count(s => s == 'S' || s == 's' || s == 'R' || s == 'r' || s == 'P' || s == 'p');

            if (intExistJogadaJogador1 > 0 && intExistJogadaJogador2 > 0)
            {
                if (objJogador1.Sinal == "R" || objJogador1.Sinal == "r")
                {
                    if(objJogador2.Sinal == "P" || objJogador2.Sinal == "p")
                    {
                        // P bate R --> Vencedor Jogador 2
                        strNomeDoVencedor = objJogador2.Nome;
                        strSinalVencedor = "Papel " + "(" + objJogador2.Sinal + ")";
                    }
                    else 
                    {
                        // R empata com R --> Vencedor Jogador 1
                        // R bate S --> Vencedor Jogador 1
                        strNomeDoVencedor = objJogador1.Nome;
                        strSinalVencedor = "Pedra " + "(" + objJogador1.Sinal + ")";
                    }
                }
                else if (objJogador1.Sinal == "S" || objJogador1.Sinal == "s")
                {
                    if (objJogador2.Sinal == "R" || objJogador2.Sinal == "r")
                    {
                        // R bate S --> Vencedor Jogador 2
                        strNomeDoVencedor = objJogador2.Nome;
                        strSinalVencedor = "Pedra " + "(" + objJogador2.Sinal + ")";
                    }
                    else
                    {
                        // S empata com S --> Vencedor Jogador 1
                        // S bate P --> Vencedor Jogador 1
                        strNomeDoVencedor = objJogador1.Nome;
                        strSinalVencedor = "Tesoura " + "(" + objJogador1.Sinal + ")";
                    }
                }
                else //if (objJogador1.Sinal == "P" || objJogador1.Sinal == "p")
                {
                    if (objJogador2.Sinal == "S" || objJogador2.Sinal == "s")
                    {
                        // S bate P --> Vencedor Jogador 2
                        strNomeDoVencedor = objJogador2.Nome;
                        strSinalVencedor = "Tesoura " + "(" + objJogador2.Sinal + ")";
                    }
                    else
                    {
                        // P empata com P --> Vencedor Jogador 1
                        // P bate R --> Vencedor Jogador 1
                        strNomeDoVencedor = objJogador1.Nome;
                        strSinalVencedor = "Papel " + "(" + objJogador1.Sinal + ")";
                    }
                }
            }
            else
                NoSuchStrategyError++;
            //--------------------------------------------
            
            objRetorno.NoSuchStrategyError = NoSuchStrategyError;
            objRetorno.WrongNumberOfPlayersError = WrongNumberOfPlayersError;
            objRetorno.NomeVencedor = strNomeDoVencedor;
            objRetorno.SinalVencedor = strSinalVencedor;

            return objRetorno;
        }
    }
}