using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.Models
{
	public class Author
	{
        public int Id { get; set; }

		public string Name { get; set; }
			
		public DateTime BirthDate  { get; set; }


		public List<Book> Books { get; set; }
    }
}
