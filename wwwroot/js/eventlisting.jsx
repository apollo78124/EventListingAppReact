

class EventBox extends React.Component {
	constructor(props) {
		super(props);
		this.state = { data: this.props.initialData };
	}

	loadEventItemsFromServer = () => {
		var xhr = new XMLHttpRequest();
		xhr.open('get', this.props.url, true);
		xhr.onload = function () {
			var data = JSON.parse(xhr.responseText);
			this.setState({ data: data });
		}.bind(this);
		xhr.send();
	};

	componentDidMount() {
		window.setInterval(
			() => this.loadEventItemsFromServer(),
			this.props.pollInterval,
		);
	}


	render() {
		return (
			<div className="col-md-8">
				<h1>Events List</h1>
				<br />
				<EventList data={this.state.data} />
			</div>
		);
	}
}

class EventList extends React.Component {
	render() {
		var eventNodes = this.props.data.map(function (eventitem) {
			return (
				<EventItem key={eventitem.id} EventName={eventitem.name} keywordForSearch={eventitem.keywordForSearching} summary={eventitem.summary} />
			);
		});
		return <div className="eventItemLists">{eventNodes}</div>;
	}
}

function createRemarkable() {
	var remarkable =
		'undefined' != typeof global && global.Remarkable
			? global.Remarkable
			: window.Remarkable;

	return new remarkable();
}

class EventItem extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			name: this.props.EventName,
			keywordForSearch: this.props.keywordForSearch,
			description: this.props.summary
		};
	}

	render() {
		return (
			<div className="eventItem">
				<h3 className="eventName">{this.state.name}</h3>
				<p className="keywordName"><b>{this.state.keywordForSearch}</b></p>
				<p className="keywordName2">{this.state.description}</p>
				<br /><br />
			</div>
		);
	}
}