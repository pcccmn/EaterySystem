package app.models;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the ref_restaurant database table.
 * 
 */
@Entity
@Table(name="ref_restaurant")
@NamedQuery(name="RefRestaurant.findAll", query="SELECT r FROM RefRestaurant r")
public class RefRestaurant implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private Integer id;

	private String code;

	private String name;

	//bi-directional many-to-one association to Menu
	@OneToMany(mappedBy="refRestaurant")
	private List<Menu> menus;

	//bi-directional many-to-one association to Order
	@OneToMany(mappedBy="refRestaurant")
	private List<Orders> orders;

	public RefRestaurant() {
	}

	public Integer getId() {
		return this.id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public List<Menu> getMenus() {
		return this.menus;
	}

	public void setMenus(List<Menu> menus) {
		this.menus = menus;
	}

	public Menu addMenus(Menu menus) {
		getMenus().add(menus);
		menus.setRefRestaurant(this);

		return menus;
	}

	public Menu removeMenus(Menu menus) {
		getMenus().remove(menus);
		menus.setRefRestaurant(null);

		return menus;
	}

	public List<Orders> getOrders() {
		return this.orders;
	}

	public void setOrders(List<Orders> orders) {
		this.orders = orders;
	}

	public Orders addOrder(Orders order) {
		getOrders().add(order);
		order.setRefRestaurant(this);

		return order;
	}

	public Orders removeOrder(Orders order) {
		getOrders().remove(order);
		order.setRefRestaurant(null);

		return order;
	}

}