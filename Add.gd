extends Button

export(NodePath) var value_path
export(float) var price
export(int) var amount = 1

func _ready():
	self.connect("pressed",self.owner,"_on_add",[price,amount,get_node(value_path)])
