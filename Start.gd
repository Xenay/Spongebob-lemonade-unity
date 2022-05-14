extends Button


func _ready():
	self.connect("pressed",self.owner,"_on_start")
