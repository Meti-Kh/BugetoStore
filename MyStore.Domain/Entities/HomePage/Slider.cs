using MyStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities.HomePage
{
  public  class Slider:BaseEntity
    {
        public string ImageSrc { get; set; }
        public string Link { get; set; }

    }
}
