using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inf3Project;

namespace Inf3Project.Observer
{
    public interface IMyObservable <T> where T: IObserver
    {
        //List of listening Observers
        public List<IObserver<T>> getObservers();  
        
        }
    }

