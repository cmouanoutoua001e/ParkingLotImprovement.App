import discord  as d
from discord.ext import commands
import asyncio

print('running')

# Client
intents = d.Intents.default()
intents.members = True
intents.presences = True
client = d.Client(intents = intents)
bot = commands.Bot(command_prefix = '!', intents = intents)
