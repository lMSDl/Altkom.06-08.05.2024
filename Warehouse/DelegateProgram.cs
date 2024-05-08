using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class DelegateProgram<T> : GenericProgram<T> where T : Entity
    {
        private Func<T> create;
        private Func<T, T> update;

        public DelegateProgram(IEntityService<T> service, Func<T> create, Func<T, T> update) : base(service)
        {
            this.create = create;
            this.update = update;
        }



        protected override T CreateNew()
        {
            return create();
        }

        protected override T CreateUpdate(T old)
        {
            return update(old);
        }
    }
}
