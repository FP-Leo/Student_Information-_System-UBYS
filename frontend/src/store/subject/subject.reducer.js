import { createSlice } from "@reduxjs/toolkit";




const initialSubject = {
    availableSubjects:[ // 1:zorunlu , 0:seçilmiş, -1:isteğe bağlı
        {id:1,akts:5,type:1},
        {id:2,akts:10,type:1},
        {id:3,akts:15,type:0},
        {id:4,akts:6,type:0},
        {id:5,akts:5,type:-1}
    ],
    selectedSubjects:[

    ],
    maxAkts:35,
    seciliAkts:0,
    kalanAkts:35,
} // başlangıçta hiçbir item ekli değil

const subjectSlice = createSlice({
    name:"subject",
    initialState:initialSubject,
    reducers:{
        add_selected_subject: (state,action) =>{ // bir dersi eklemek için olan fonksiyon
            if(state.kalanAkts >0 && (state.seciliAkts + action.payload.akts) <= state.maxAkts){
                state.selectedSubjects.push(action.payload) // bize verilen selectedSubject'e item pushluyoruz
                state.seciliAkts +=action.payload.akts
                state.kalanAkts -= action.payload.akts
            }else{
               throw new Error("AKTS'yi aşacağınızdan dolayı bu dersi ekleyemezsiniz")
            }
        },
        remove_from_available : (state,action)=>{ // seçilebilir olan derslerden kaldırmak için olan fonksiyon
            state.availableSubjects = state.availableSubjects.filter((item)=>item.id !== action.payload)
        },

    }
})


export const {add_selected_subject,remove_from_available,change_enabled} = subjectSlice.actions;
export default subjectSlice.reducer;