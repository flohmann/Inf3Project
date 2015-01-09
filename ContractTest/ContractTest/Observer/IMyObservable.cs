using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project.Observer
{
    public interface IMyObservable <T> where T: IObserver // #where man kann T beschränken, LÖSCHEN
    {
        //List of listening Observers
        public List<IObserver<T>> getObservers();  
        
        }
    }

