using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksMVC.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        /// <summary>
        /// El título de la tarea
        /// </summary>
        [Required]
        public string Titulo { get; set; }

        /// <summary>
        /// Nombre de quién fue asignado
        /// </summary>
        [Required]
        public string AsignadaA { get; set; }

        /// <summary>
        /// Determina si una tarea está completada o no
        /// </summary>
        public bool Completada { get; set; }
    }
}