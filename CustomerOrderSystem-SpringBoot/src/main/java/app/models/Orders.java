package app.models;

import java.io.Serializable;
import javax.persistence.*;

import lombok.Data;


/**
 * The persistent class for the orders database table.
 * 
 */
@Entity
@Data
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
	@ManyToOne
	@JoinColumn(name="food_id")
	private RefFood refFood;

	//bi-directional many-to-one association to RefRestaurant
	@ManyToOne
	@JoinColumn(name="restaurant_id")
	private RefRestaurant refRestaurant;
	
}