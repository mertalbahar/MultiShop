﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos
{
    public class ResultCargoCustomerDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}