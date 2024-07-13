﻿using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ResultProductDto> Products { get; set; }
    }
}