﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapo.Repository
{
    public interface IDapperQueryPartsGenerator<TEntity> where TEntity : class
    {
        string GenerateSelect();
        string GenerateSelect(object fieldsFilter);
        string GeneratePartInsert(string identityField = null);
        string GenerateDelete(object parameters);
        string GenerateUpdate(object pks);
    }
}
