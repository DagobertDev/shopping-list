function ListItem({name, deleteItem}){
    return (
        <li>
            {name}
            <button onClick={deleteItem}>Remove</button>
        </li>
    )
}

export default ListItem
