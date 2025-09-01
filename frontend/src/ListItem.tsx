import type { ShoppingItem } from "./ShoppingItem";

interface ListItemProps {
    item: ShoppingItem;
    deleteItem: () => void;
}

function ListItem({item, deleteItem}: ListItemProps) {
    return (
        <li>
            {item.name}
            <button onClick={deleteItem}>Remove</button>
        </li>
    )
}

export default ListItem
