package app.models;

import java.io.Serializable;
import javax.persistence.*;

import lombok.Data;


/**
 * The persistent class for the menu database table.
 * 
 */
@Entity
@Data
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

}