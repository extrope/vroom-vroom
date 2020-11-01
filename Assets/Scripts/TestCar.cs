using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCar : MonoBehaviour {
	public class Wheel {
		public readonly Transform transform;
		public readonly WheelCollider collider;
		
		public Wheel(string name, GameObject models, GameObject hubs) {
			this.transform = models.GetChild(name).transform;
			this.collider = hubs.GetChild(name).GetOnlyComponent<WheelCollider>();
		}
	}
	
	public class WheelPair : IEnumerable<Wheel> {
		public readonly Wheel left;
		public readonly Wheel right;
		
		public WheelPair(string prefix, GameObject models, GameObject hubs) {
			this.left = new Wheel($"{prefix} Left", models, hubs);
			this.right = new Wheel($"{prefix} Right", models, hubs);
		}
		
		public IEnumerator<Wheel> GetEnumerator() {
			yield return this.left;
			yield return this.right;
		}
		
		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}
		
		public IEnumerable<Transform> Transforms {
			get {
				foreach (var wheel in this) {
					yield return wheel.transform;
				}
			}
		}
		
		public IEnumerable<WheelCollider> Colliders {
			get {
				foreach (var wheel in this) {
					yield return wheel.collider;
				}
			}
		}
	}
	
	public class Wheels {
		public readonly WheelPair rear;
		public readonly WheelPair front;
		
		public Wheels(GameObject models, GameObject hubs) {
			this.rear = new WheelPair("Rear", models, hubs);
			this.front = new WheelPair("Front", models, hubs);
		}
		
		public IEnumerable<Wheel> All {
			get {
				return Utils.Cat(this.rear, this.front);
			}
		}
	}
	
	private Rigidbody rigidbodily;
	
	public Wheels wheels;
	public float motorRatio = 0.5f;
	public float motorTorque = 2000f;
	public float maxSteer = 20f;
	
	void Start() {
		this.rigidbodily = this.gameObject.GetOnlyComponent<Rigidbody>();
		InitCenterOfMass();
		InitWheels();
	}
	
	void InitWheels() {
		var models = this.gameObject.GetDescendant("Model", "Wheels");
		var hubs = this.gameObject.GetDescendant("Wheels");
		this.wheels = new Wheels(models, hubs);
	}
	
	void InitCenterOfMass() {
		this.rigidbodily.centerOfMass =
			this.gameObject.GetDescendant("Center Of Mass").transform.localPosition;
	}
	
	void FixedUpdate() {
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		
		//var velocity = this.transform.InverseTransformDirection(this.rigidbodily.velocity).z;
		
		float motorTorque = vertical * this.motorTorque;
		
		var torqueRear = motorTorque * motorRatio;
		var torqueFront = motorTorque - torqueRear;
		var steer = horizontal * this.maxSteer;
		
		foreach (var collider in this.wheels.rear.Colliders) {
			collider.motorTorque = torqueRear;
		}
		
		foreach (var collider in this.wheels.front.Colliders) {
			collider.motorTorque = torqueFront;
			collider.steerAngle = steer;
		}
	}
	
	void Update() {
		foreach (var wheel in this.wheels.All) {
			var position = Vector3.zero;
			var rotation = Quaternion.identity;
			wheel.collider.GetWorldPose(out position, out rotation);
			
			var transform = wheel.transform;
			transform.position = position;
			transform.rotation = rotation;
		}
	}
	
	/*
	
	void InitWheels() {
		var models = GetDescendant("Model", "Wheels").GetEnumerator();
		var hubs = GetDescendant("Wheel Hubs").GetEnumerator();
	}
	
	void Start() {
		
		var wheelCount = AssertPlus.AreEqual(Utils.Map(group => group.ChildCount, wheelModels, wheelHubs));
		this.wheels = Utils.Zip(
			(model, hub) => new Wheel(hub.GetComponent<WheelCollider>(), model.GetComponent<Transform>()),
			GetDescendant("Model", "Wheels"),
			GetDescendant("Wheel Hubs")
		).ToArray(4);
	}
	
	*/
	
	/*
    
	
	void Start() {
		
		this.transform.GetEnumerator();
	}
	
	Transform GetModel() {
		foreach (Transform child in this.transform) {
			if (child )
		}
	}
	
	Transform GetWheels() {
		
	}
	
	Transform GetWheelHubs() {
		
	}
	
	void Update() {
		
	}
	*/
}
