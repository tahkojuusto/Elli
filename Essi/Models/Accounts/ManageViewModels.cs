using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Essi.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
    }
}