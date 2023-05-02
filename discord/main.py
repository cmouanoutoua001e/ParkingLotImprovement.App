import discord
from discord.ext import commands
import datetime
from hidden import key
from lib import func

print('running')

# Client
intents = discord.Intents.default()
intents.members = True
intents.presences = True
intents.message_content = True
bot = commands.Bot(command_prefix = '!', intents = intents)

""" Global vars """
@bot.event
async def on_ready():
    
    print("Now we're cooking")
    
    # channels:
    general = bot.get_channel(1099948525892149280) #FIXME
    beep = bot.get_channel(1099960596943863818)

    # Init Message
    now = datetime.datetime.now()
    dt_string = now.strftime(f"%d/%m/%Y %H:%M:%S")
    await beep.send(f"\n \n ** Run time: {dt_string} * \n \n")
    
""" UPDATE COMMAND """
# 1. requests openCV data
# 2. Changes parking lot map to match open sports
# 3. send to discord channel

@bot.command()
async def update(ctx):
    await ctx.send("Yay! This is the main function :D")
    
    # Send image uwu
    
    with open('lib/images/queen.jpg', 'rb') as f:
        picture = discord.File(f)
        await ctx.send("Insert Photo of processed parking lot photo", file=picture)

""" BOT KEY """
# key located in private folder

bot.run(key.botKey)