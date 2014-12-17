var oldMenu_HideItems = Menu_HideItems;
if(oldMenu_HideItems)
{
Menu_HideItems = function(items){
if (!items || ((typeof(items.tagName) == "undefined") && (items instanceof Event))) { items = __rootMenuItem; }
if(items && items.rows && items.rows.length == 0){ items.insertRow(0); }
return oldMenu_HideItems(items);
}
}
