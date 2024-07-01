﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox
{
    public class CheckBoxIPropertyDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsChecked { get; set; } = false;
    }
}
