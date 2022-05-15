package app.models;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the orders database table.
 * 
 */
@Entity
@NamedQuery(name="Order.findAll", query="SELECT o FROM Orders o")
public class Orders implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private Integer id;

	@Column(name="is_active")
	private Integer isActive;

	private Integer quantity;

	@Column(name="table_number")
	private Integer tableNumber;

	//bi-directional many-to-one association to RefFood
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="food_id")
	private RefFood refFood;

	//bi-directional many-to-one association to RefRestaurant
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="restaurant_id")
	private RefRestaurant refRestaurant;

	public Orders() {
	}

	public Integer getId() {
		return this.id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public Integer getIsActive() {
		return this.isActive;
	}

	public void setIsActive(Integer isActive) {
		this.isActive = isActive;
	}

	public Integer getQuantity() {
		return this.quantity;
	}

	public void setQuantity(Integer quantity) {
		this.quantity = quantity;
	}

	public Integer getTableNumber() {
		return this.tableNumber;
	}

	public void setTableNumber(Integer tableNumber) {
		this.tableNumber = tableNumber;
	}

	public RefFood getRefFood() {
		return this.refFood;
	}

	public void setRefFood(RefFood refFood) {
		this.refFood = refFood;
	}

	public RefRestaurant getRefRestaurant() {
		return this.refRestaurant;
	}

	public void setRefRestaurant(RefRestaurant refRestaurant) {
		this.refRestaurant = refRestaurant;
	}

}