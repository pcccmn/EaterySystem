package app.services;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import app.models.Orders;

@Service
@Scope("prototype")
public class OrderService {

	private static final Logger log = LoggerFactory.getLogger(OrderService.class);
	
	private SessionFactory sessionFactory;
	
	@Autowired
	public OrderService(EntityManagerFactory factory) {
	    if(factory.unwrap(SessionFactory.class) == null){
	      throw new NullPointerException("factory is not a hibernate factory");
	    }
	    this.sessionFactory = factory.unwrap(SessionFactory.class);
	}
	
	public ResponseEntity<List<Orders>> get(int restaurantId, int tableNumber){
		
		try(Session session = sessionFactory.openSession())
		{
			String query = "FROM Orders WHERE refRestaurant.id = :restaurantId AND tableNumber = :tableNumber";
			
			List<Orders> orders = session.createQuery(query, Orders.class)
			.setParameter("restaurantId", restaurantId)
			.setParameter("tableNumber", tableNumber)
			.getResultList(); 
			
			return new ResponseEntity<List<Orders>>(orders, HttpStatus.OK);
			
		} catch (Exception e) {
			
			log.error(e.getMessage());
			
		}
		
		return null;
		
	}
	
	
}
