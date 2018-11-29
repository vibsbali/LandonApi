using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LandonApi.Models
{
    public class HotelInfo : Resource
    {
        public string Title { get; set; }
        public string TagLine { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Address Location { get; set; }
    }
}
