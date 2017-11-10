using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win_forms
{
    interface ViewInterface
    {
        void Open(List<SongModel> initData);
        bool AddData(SongModel song);
        bool RemoveData(SongModel song);
        bool ModifyData(SongModel dest, SongModel src, change mask);
        void Exit();
    }
}
