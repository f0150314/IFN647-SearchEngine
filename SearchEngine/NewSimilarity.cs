using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Search;

namespace SearchEngine
{
    public class NewSimilarity : DefaultSimilarity
    {
        public override float Tf(float freq)
        {
            return 30;
        }
    }
}
