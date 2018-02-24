using MyWalletApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyWalletApp.Models
{
    public class SearchListViewModel
    {
        public IEnumerable<IngresoDto> Ingresos { get; set; }
        [DisplayName("Search")]
        public string SearchCriteria { get; set; }
    }
}