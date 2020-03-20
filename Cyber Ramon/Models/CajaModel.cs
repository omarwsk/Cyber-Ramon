using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyber_Ramon.Models
{
    public class CajaModel
    {
        private DateTime Fecha;
        private String Turno;
        private Double Fondo;
        private Double Corte;
        private Double Sobre;
        private Double Caja;

        private Double Entrada;
        private Double Salida;

        public CajaModel(DateTime fecha, String turno, Double fondo, Double corte, Double sobre, Double caja, Double entrada, Double salida) 
        {
            Fecha = fecha;
            Turno = turno;
            Fondo = fondo;
            Corte = corte;
            Sobre = sobre;
            Caja = caja;
            Entrada = entrada;
            Salida = salida;
        }
    }
}