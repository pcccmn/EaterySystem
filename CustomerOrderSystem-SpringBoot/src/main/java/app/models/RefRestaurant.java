package app.models;

import java.io.Serializable;
import javax.persistence.*;

import lombok.Data;

import java.util.List;


/**
 * The persistent class for the ref_restaurant database table.
 * 
 */
@Entity
@Data
@Table(name="ref_restaurant")
public class RefRestaurant implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private Integer id;

	private String code;

	private String name;

	
}