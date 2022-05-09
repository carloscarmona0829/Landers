
// import React, { useState, useEffect } from "react";

// const Search = () => {    
//     const [tablaProductos, setTablaProductos] = useState("");
//     const [search, setSearch] = useState([]);

//     const url = "https://localhost:7062/api/Productos"

//     const showData = async () => {
//         const response = await fetch(url)
//         const data = await response.json()
//         console.log(data)
//     }

//     const searcher =(e) => {
//         setSearch(e.target.value)
//         console.log(e.target.value)
//     }

//     let results = []
//     if(!search){
//         results = tablaProductos        
//     }else{
//         results=tablaProductos.filter((dato) => 
//         dato.name.toLowerCase().includes(search.toLocaleLowerCase())
//         ) 
//     }  

//     return (
//         <div>
//             <input value={search} onChange={searcher} type="text" placeholder='Search...' className='form-control' />
//         </div>

//     )
// }

// export default Search