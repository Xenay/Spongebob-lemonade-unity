extends Node2D


const fish = preload("res://Fish.tscn")

var time = 0
# Called when the node enters the scene tree for the first time.
func _ready():
	$Timer.connect("timeout",self,"spawn_fish")

func _on_start(temp_factor):
	$Timer.start(1.8-temp_factor)
	time = 0
	
func spawn_fish():
	time += $Timer.wait_time
	if time >= 15:
		$Timer.stop()
	var x_offset = (randi() % 200) - 100
	var y_offset = (randi() % 80) - 40
	
	var instance = fish.instance()
	instance.position = Vector2(x_offset,y_offset)
	instance.z_index = y_offset+41
	instance.connect("buy_lemonade",owner,"_on_buy_lemonade")
	
	self.add_child(instance)
