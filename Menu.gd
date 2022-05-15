extends Node

onready var day = $"Menu/left side/Day/Value"
onready var money = $"Menu/left side/Money/Value"
onready var temperature = $"Menu/right side/Temperature/Value"
onready var weather = $"Menu/right side/Weather/Value"
onready var price = $"Menu/Start/Recipe/Price/Value"

export var min_temp : int = 18
export var max_temp : int = 38

var temperature_factor
var recipe_factor
var cost_factor 

var pitcher = 0

signal on_start(temperature_factor)

const WEATHER = ["rain","cloudy","sunny"]
# Called when the node enters the scene tree for the first time.
func _ready():
	$Timer.connect("timeout",self,"_on_timer_timeout")
	$Menu/InGame/HSlider.connect("value_changed",self,"_on_slider_change")
	
	self.connect("on_start",$"Game/spawn left","_on_start")
	
	self.connect("on_start",$"Game/spawn right","_on_start")
	randomize()
	var temp = (randi() % (max_temp-min_temp+1))+min_temp
	temperature.text = str(temp)
	weather.text = WEATHER[int((temp-min_temp)/((max_temp+1-min_temp)/3.0))]

func _on_slider_change(value):
	$Menu/InGame/Label.text = "Price: "+str(value)+" cents"
	price.text = str(value)
	cost_factor = (100 - int(price.text))/100.0
	
func _on_timer_timeout():
	print("end")
	$Menu/Start.visible = true
	$Menu/InGame.visible = false
	
	var temp = (randi() % (max_temp-min_temp+1))+min_temp
	day.text = str(int(day.text)+1)
	temperature.text = str(temp)
	weather.text = WEATHER[int((temp-min_temp)/((max_temp+1-min_temp)/3.0))]

func _on_start():
	print("start")
	
	$Menu/InGame/Label.text = "Price: "+price.text+" cents"
	$Menu/InGame/HSlider.value = int(price.text)
	$Menu/Start.visible = false
	$Menu/InGame.visible = true
	
	$Menu/InGame/top/Cups/Value.text = $Menu/Start/Inventory/Cups/Value.text
	$Menu/InGame/top/Lemons/Value.text = $Menu/Start/Inventory/Lemons/Value.text
	$Menu/InGame/top/Sugar/Value.text = $Menu/Start/Inventory/Sugar/Value.text
	$Menu/InGame/top/Ice/Value.text = $Menu/Start/Inventory/Ice/Value.text
	
	temperature_factor = (int(temperature.text)-(min_temp/2.0))/(max_temp-(min_temp/2.0))
	cost_factor  = (100 - int(price.text))/100.0
	
	var lemons = int($Menu/Start/Recipe/Lemons/Value.text)
	var sugar = int($Menu/Start/Recipe/Sugar/Value.text)
	var ice = int($Menu/Start/Recipe/Ice/Value.text)
	
	if weather.text == "rain":
		recipe_factor = (lemons+sugar-1.75*ice)/5.0
	elif weather.text == "cloudy":
		recipe_factor = (lemons+sugar+0.5*ice)/8.0
	else:
		recipe_factor = (1.5*ice-lemons-sugar)/5.0
	recipe_factor = max(min(recipe_factor,1.5),0.1)
	
	$Timer.start(20)
	emit_signal("on_start",temperature_factor)
	
func _on_add(price,amount,node):
	var temp_money = float(money.text)
	if temp_money-price >= 0 and int(node.text)+amount >= 0:
		node.text = str(int(node.text)+amount)
		money.text = str(temp_money-price) + " $"

func _on_buy_lemonade():
	if randf() > recipe_factor*temperature_factor*cost_factor:
		return
	if int($Menu/Start/Inventory/Cups/Value.text) - 1 < 0:
		return
	if int($Menu/Start/Inventory/Ice/Value.text) - int($Menu/Start/Recipe/Ice/Value.text) < 0:
		return
	if pitcher == 0:
		if not refill_pitcher():
			return
	money.text = str(float(money.text)+int(price.text)/100.0)+" $"
	pitcher -= 1
	$Menu/Start/Inventory/Cups/Value.text   = str(int($Menu/Start/Inventory/Cups/Value.text) - 1)
	$Menu/Start/Inventory/Ice/Value.text = str(int($Menu/Start/Inventory/Ice/Value.text) - int($Menu/Start/Recipe/Ice/Value.text)) 
	$Menu/InGame/top/Pitcher/Value.text = str(pitcher)
	$Menu/InGame/top/Cups/Value.text = $Menu/Start/Inventory/Cups/Value.text
	$Menu/InGame/top/Ice/Value.text = $Menu/Start/Inventory/Ice/Value.text
	print("sale made")
func refill_pitcher():
	if int($Menu/Start/Inventory/Lemons/Value.text) - int($Menu/Start/Recipe/Lemons/Value.text) < 0:
		return false
	if int($Menu/Start/Inventory/Sugar/Value.text) - int($Menu/Start/Recipe/Sugar/Value.text) < 0:
		return false
	$Menu/Start/Inventory/Lemons/Value.text = str(int($Menu/Start/Inventory/Lemons/Value.text) - int($Menu/Start/Recipe/Lemons/Value.text))
	$Menu/Start/Inventory/Sugar/Value.text = str(int($Menu/Start/Inventory/Sugar/Value.text) - int($Menu/Start/Recipe/Lemons/Value.text)) 
	$Menu/InGame/top/Lemons/Value.text = $Menu/Start/Inventory/Lemons/Value.text
	$Menu/InGame/top/Sugar/Value.text = $Menu/Start/Inventory/Sugar/Value.text
	pitcher = 8
	
	return true
