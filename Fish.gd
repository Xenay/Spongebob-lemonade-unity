extends Sprite

export var speed = 100 

signal buy_lemonade

func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	self.position.x -= speed * delta
	if abs(self.global_position.x-270) < 1:
		emit_signal("buy_lemonade")
