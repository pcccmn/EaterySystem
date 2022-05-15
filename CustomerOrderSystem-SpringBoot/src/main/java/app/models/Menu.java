package app.models;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the menu database table.
 * 
 */
@Entity
@NamedQuery(name="Menu.findAll", query="SELECT m FROM Menu m")
public class Menu implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private Integer id;

	private Double price;

	//bi-directional many-to-one association to RefFood
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="food_id")
	private RefFood refFood;

	//bi-directional many-to-one association to RefRestaurant
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="restaurant_id")
	private RefRestaurant refRestaurant;

	public Menu() {
	}

	public Integer getId() {
		return this.id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public Double getPrice() {
		return this.price;
	}

	public void setPrice(Double price) {
		this.price = price;
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