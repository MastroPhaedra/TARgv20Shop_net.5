﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targv20Shop.Core.Domain
{
    public class ExistingFilePath
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CarId { get; set; }

        // что бы EF Core мог сам доставать объекты и настраивать связи с миграциями
        public Car Car { get; set; }
        public Product Product { get; set; }
    }
}
