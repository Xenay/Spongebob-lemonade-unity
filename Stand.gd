extends Spatial


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	var timer = Timer.new()
	timer.set_one_shot(true)
	timer.set_timer_process_mode(0)
	timer.set_wait_time(5)
	timer.connect("timeout", self, "_emit_timer_end_signal")
	self.add_child(timer)
	timer.start()

func _emit_timer_end_signal():
	get_tree().change_scene("res://Menu.tscn")
