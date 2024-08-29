using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosApp.Application
{
    public class CreateProductCommand : IRequest<int>

    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public required bool Status { get; set; }
        public required IEnumerable<string> Images
        {
            get; set;
        }
    }
}
