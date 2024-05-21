import java.util.ArrayList;
import java.util.List;

public class ShoppingCart {
    private List<String> items;
    private boolean bookAdded;

    public ShoppingCart() {
        items = new ArrayList<>();
        bookAdded = false;
    }

    public void addItem(String item) {
        items.add(item);
        if (item.contains("book")) {
            bookAdded = true;
        }
    }

    public void removeItem(String item) {
        items.remove(item);
        if (!item.contains("book")) {
            bookAdded = false;
        }
    }

    public double getDiscount() {
        if (bookAdded) {
            return 0.05;
        } else {
            return 0.0;
        }
    }

    public List<String> getItems() {
        return items;
    }

    public static void main(String[] args) {
        ShoppingCart cart = new ShoppingCart();
        cart.addItem("apple");
        cart.addItem("banana");
        cart.addItem("book");
        System.out.println("Discount: " + cart.getDiscount());
        System.out.println("Items: " + cart.getItems());
        cart.removeItem("book");
        System.out.println("Discount: " + cart.getDiscount());
        System.out.println("Items: " + cart.getItems());
    }
}