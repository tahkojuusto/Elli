using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Essi.Models
{
    /// <summary>
    /// Might be redundant. Not removing it just to make sure..
    /// </summary>
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
    }
}