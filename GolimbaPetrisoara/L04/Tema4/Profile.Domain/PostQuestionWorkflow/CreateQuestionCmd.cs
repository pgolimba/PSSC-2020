using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Domain.CreateProfileWorkflow
{
    public struct CreatequestionCmd
    {
        [Required]
        public string Title { get; private set; }
        public string Continut { get; set; }
        

        public CreatequestionCmd(string title, string continut)
        {
            Title = title;
            Continut = continut;
        }
    }
}
