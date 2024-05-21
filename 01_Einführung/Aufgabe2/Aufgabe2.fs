let getDiscountPercentage (shoppingList: list<string>) = 
    List.exists (fun i -> i = "book") shoppingList